import React from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import { AuthContextComponent } from './AuthContext';
import Layout from './Layout';
import Home from './Home';
import Signup from './Signup';

class App extends React.Component {


    onButtonClick = () => {
        this.setState({ count: this.state.count + 1 });
    }

    render() {
        return (
            <AuthContextComponent>
                <Layout>
                    <Routes>
                        <Route exact path='/' component={<Home />} />
                        <Route exact path='/signup' element={<Signup />} />
                    </Routes>
                </Layout>
            </AuthContextComponent>
        );
    }
};

export default App;