class LogBox extends React.Component {
    constructor(props) {
        super(props);
    }

    //render() {
    //    return (<div class="col-md-4">
    //        <h1>Id</h1>
    //        <p>Host</p>
    //        <p>Error</p>
    //        <hr />
    //    </div>
    //    );
    //}

    render() {
        const LogList = this.props.logData.map(b => 
        (
            <div class="col-md-4">
                <h1>{b.Id}</h1>
                <p>{b.Host}</p>
                <p>{b.Error}</p>
                <hr/>
            </div>
        ));
        return LogList
    }
}