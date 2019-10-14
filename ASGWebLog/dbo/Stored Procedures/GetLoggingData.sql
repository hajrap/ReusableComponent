-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLoggingData] --true,'05/29/2019','05/30/2019','Debug, Error, Info',null,0,1,10
	-- Add the parameters for the stored procedure here
	@IsSearch bit = false,
	@StartDt varchar(50),
	@EndDt varchar(50),
	@Level varchar(max),
	@UserId varchar(50),
	@Id int = 0,
	@PageNo int= 0,
	@TotalRows int = 10
AS
BEGIN

	IF(@IsSearch = 'true')
	Begin
		
		declare @temp varchar(max) = ''
		declare @condition varchar(max) = ''

		set @temp = 'SELECT [Id]
			  ,[TimeStamp]
			  ,[Level]
			  ,[Host]
			  ,[Type]
			  ,[Logger]
			  ,[Message]
			  ,[stacktrace]
			  , '


		if(Isnull(@Level,'') <> '')
		Begin
			
			set @condition += '[Level] IN (SELECT value FROM SplitString('''+ @Level + ''','','')) and '
		End
		
		if(Isnull(@UserId,'') <> '')
		Begin
			set @condition += '''' + @UserId +''' = Host and '
		End

		if(@Id <> 0)
		Begin
			set @condition += '''' +@Id +''' = Id and '
		End

		if(Isnull(@StartDt,'') <> '')
		Begin
			set @condition += 'FORMAT([TimeStamp],''MM/dd/yyyy'') >= Cast('''+ @StartDt +''' AS DATETIME2) and FORMAT([TimeStamp],''MM/dd/yyyy'') <= Cast('''+ @EndDt +''' AS DATETIME2)  and '
		End

		if(@condition <> '')
		Begin
			set @condition = LEFT(@condition, LEN(@condition)-4)
		End

		set @temp += ' (select count(*) from NLog_Error where '+ @condition +') as TotalCount'
		set @temp += ' from [NLog_Error] where '
		set @temp += @condition
		set @temp += ' order by [TimeStamp] desc'
		set @temp += ' OFFSET '+ Cast(((@PageNo - 1) * @TotalRows) as varchar) +' ROWS FETCH NEXT '+ Cast(@TotalRows as varchar) +' ROWS ONLY'
		
		print (@temp)
		EXECUTE(@temp)
		
	END
	Else
	Begin

		SELECT [Id]
			  ,[TimeStamp]
			  ,[Level]
			  ,[Host]
			  ,[Type]
			  ,[Logger]
			  ,[Message]
			  ,[stacktrace]
			  , (select count(*) from NLog_Error) as TotalCount
		from [NLog_Error] 
		order by [TimeStamp] desc
		OFFSET ((@PageNo - 1) * @TotalRows) ROWS FETCH NEXT @TotalRows ROWS ONLY
	END
END
