import React from 'react';
import {useParams } from "react-router-dom";
 
const Movie:React.FC = ():JSX.Element => {
        const routeParams = useParams();

        return <>Single movie view {routeParams.id}</> 
};

export default Movie