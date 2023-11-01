import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from './AuthContext';

const Layout = (props) => {
    const { user } = useAuth();
    return (
        <div>
            <nav className="navbar navbar-expand-sm navbar-dark fixed-top bg-dark border-bottom box-shadow">
                <div className="container">
                    <a className="navbar-brand" href="/">
                        React Bookmark Manager
                    </a>
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target=".navbar-collapse"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span className="navbar-toggler-icon" />
                    </button>
                    <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                        <ul className="navbar-nav flex-grow-1">
                            <li className="nav-item">
                                {!user ? <Link to="/signup" className="nav-link text-light"> Signup </Link> 
                                :  <Link to="/mybookmarks" className="nav-link text-light"> My Bookmarks </Link>}
                            </li>
                            <li className="nav-item">
                                {!user ? <Link to="/login" className="nav-link text-light"> Login </Link> 
                                : <Link to="/addbookmark" className="nav-link text-light"> Add Bookmark </Link> }
                            </li>
                            {!!user && <li className="nav-item">
                                <Link to="/logout" className="nav-link text-light"> Logout </Link>
                            </li>}
                        </ul>
                    </div>
                </div>
            </nav>

            <div className="container" style={{ marginTop: 80 }}>
                <main role="main" className="pb-3">
                    {props.children}
                </main>
            </div>

        </div>
    )
}

export default Layout;