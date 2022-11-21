import React from 'react';
import {useParams } from "react-router-dom";

const AddMovie:React.FC = ():JSX.Element => {
    const routeParams = useParams();

    return <>Single movie view {routeParams.id}</> //+ useParams()["id"];
};

export default AddMovie