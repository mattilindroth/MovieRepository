import React from 'react';
import {useParams } from "react-router-dom";
 
export interface IMovieProps  {
    movieId?: string;
}

const Movies:React.FC = ():JSX.Element => {
        const routeParams = useParams();

        return <>Single movie view {routeParams.id}</> //+ useParams()["id"];
};

export default Movies