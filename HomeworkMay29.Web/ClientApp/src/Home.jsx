const Home = () =>{
    return(
    <div>
                        <h1>Welcome to the React Bookmark Application.</h1>
                        <h3>Top 4 most bookmarked links</h3>
                        <table className="table table-hover table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Url</th>
                                    <th>Count</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <a href="https://stackoverflow.com" target="_blank">
                                            https://stackoverflow.com
                                        </a>
                                    </td>
                                    <td>14</td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="https://lakewoodprogramming.com" target="_blank">
                                            https://lakewoodprogramming.com
                                        </a>
                                    </td>
                                    <td>13</td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="https://microsoft.com" target="_blank">
                                            https://microsoft.com
                                        </a>
                                    </td>
                                    <td>12</td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="https://www.npmjs.com/" target="_blank">
                                            https://www.npmjs.com/
                                        </a>
                                    </td>
                                    <td>11</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
    )
}
export default Home;