import React from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import { AuthContextComponent, useAuth } from './AuthContext';
import Layout from './Layout';
import Home from './Home';
import Signup from './Signup';
import Login from './Login';
import Logout from './Logout';
import AddBookmark from './AddBookmark';
import MyBookmarks from './MyBookmarks';
import PrivateRoute from './PrivateRoute';

class App extends React.Component {

    render() {
        return (
            <AuthContextComponent>
                <Layout>
                    <Routes>
                        <Route exact path='/' element = {<Home/>} />
                        <Route exact path='/signup' element={<Signup />} />
                        <Route exact path='/login' element = {<Login/>} />
                        <Route exact path='/logout' element = {<Logout/>} />
                        <Route exact path='/addbookmark' element = {<PrivateRoute> <AddBookmark/> </PrivateRoute>} />
                        <Route exact path='/mybookmarks' element = {<PrivateRoute> <MyBookmarks/> </PrivateRoute>}/>
                    </Routes>
                </Layout>
            </AuthContextComponent>
        );
    }
};

export default App;