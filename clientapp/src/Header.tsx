import React from 'react';
import {useParams } from "react-router-dom";
import Link from '@mui/material/Button';


const Header:React.FC = ():JSX.Element => {
	return <>
				<Link variant="contained" href='/' >View movies</Link>
				<Link variant="contained" href='/add'>Add</Link>
				<Link variant="contained" href="/search">Search</Link>
			</> 
};

export default Header