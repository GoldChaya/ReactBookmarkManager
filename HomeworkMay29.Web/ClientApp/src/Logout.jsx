import React, {useEffect} from 'react';
import axios from 'axios';
import { useAuth } from './AuthContext';
import { useNavigate } from 'react-router-dom';

const Logout = () => {
    
    const { setUser } = useAuth();
    const navigate = useNavigate();

    useEffect(() => {
        const doLogout = async () => {
            await axios.post('/api/user/logout');
            setUser(null);
            navigate('/');
        }
        doLogout();
    }, []);
    
    return (<></>);
}

export default Logout;