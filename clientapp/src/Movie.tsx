import React, {useState, useEffect} from 'react';
import {useParams } from "react-router-dom";
import Movie from './Models/Movie';
import axios from 'axios';
import {Table, TableContainer, Paper, TableRow, TableCell, TableBody, TableHead,Card, CardContent, Typography, Rating } from '@mui/material';
 
const MovieView:React.FC = ():JSX.Element => {
        const routeParams = useParams();

        const [movie, setMovie] = useState<Movie>();

        useEffect(() => {
            if(movie === undefined || movie === null) {
                axios.get("https://localhost:49159/Movies/" + routeParams.id).then(function(response) {
                    console.log(response.data);
                    let movie: Movie = response.data;
                    setMovie(movie);
                }).catch(function(error) {console.log(error)});
            }
        });
        
        if(movie === undefined ||movie == null)
            return <>...Loading...</>

        return <Card sx={{ minWidth: 275 }}>
                <CardContent>
                    <Typography variant="h3">{movie.name}</Typography>
                    <TableContainer component={Paper}>
                        <Table sx={{ minWidth: 650, maxWidth: 1400 }} aria-label="simple table">
                            <TableHead>
                            <TableRow>
                                <TableCell>Rating</TableCell>
                                <TableCell><Rating name="read-only" value={movie.rating} readOnly /></TableCell>
                            </TableRow>
                            </TableHead>
                            <TableBody>
                                {/* Genres */}
                                <TableRow >
                                    <TableCell component="th" scope="row">
                                        Genres
                                    </TableCell>
                                    <TableCell>{movie.genres.map((genre) => genre + " ")}</TableCell>
                                </TableRow>

                                {/* Synopsis */}
                                <TableRow>
                                    <TableCell component="th" scope="row">
                                        Synopsis
                                    </TableCell>
                                    <TableCell>{movie.synopsis}</TableCell>
                                </TableRow>

                                {/* Year */}
                                <TableRow>
                                    <TableCell component="th" scope="row">
                                        Year of release
                                    </TableCell>
                                    <TableCell>{movie.year}</TableCell>
                                </TableRow>

                                {/* Actors */}
                                <TableRow>
                                    <TableCell component="th" scope="row">
                                        Actors
                                    </TableCell>
                                    <TableCell>{movie.actors.map((oneActor) => oneActor.firstName + " " + oneActor.lastName)}</TableCell>
                                </TableRow>

                                {/* Director */}
                                <TableRow>
                                    <TableCell component="th" scope="row">
                                        Director
                                    </TableCell>
                                    <TableCell>{movie.director.firstName + " " + movie.director.lastName}</TableCell>
                                </TableRow>

                                {/* Director */}
                                <TableRow>
                                    <TableCell component="th" scope="row">
                                        Age limit
                                    </TableCell>
                                    <TableCell>{movie.ageLimit}</TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                    </TableContainer>
            </CardContent>
            </Card>
};

export default MovieView