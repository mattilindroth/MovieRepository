import React, {useState, useEffect} from 'react';
import axios from 'axios';
import Movie from '../Models/Movie';
import BackendUrl from '../Axios/AxiosConfig';
import {Table, TableContainer, Paper, TableRow, TableCell, TableBody, TableHead,Card, CardContent, Typography, Link } from '@mui/material';

const Movies:React.FC = ():JSX.Element => {    

        const [movies, setMovies] = useState<Array<Movie>>([]);

        useEffect(() => {
            if(movies.length === 0) {
                axios.get(BackendUrl + "/Movies").then(function(response) {
                    console.log(response.data);
                    let movieList: Array<Movie> = response.data;
                    setMovies(movieList);
                }).catch(function(error) {console.log(error)});
            }
        });       
        
        if(movies.length === 0) {
            return <div>...Loading...</div>
        }

        return <Card sx={{ minWidth: 275 }}>
                <CardContent>
                    <Typography variant="h3">Movies listing</Typography>
                    <TableContainer component={Paper}>
                        <Table sx={{ minWidth: 650, maxWidth: 1400 }} aria-label="simple table">
                            <TableHead>
                            <TableRow>
                                <TableCell><Typography variant="h5">Name</Typography></TableCell>
                                <TableCell align="right"><Typography variant="h5">Genres</Typography></TableCell>
                                <TableCell align="right"><Typography variant="h5">Year</Typography></TableCell>
                            </TableRow>
                            </TableHead>
                            <TableBody>
                            {movies.map((oneMovie: Movie, index: number) => (
                                <TableRow key={index.toString()} sx={{ '&:last-child td, &:last-child th': { border: 0 } }} >
                                    <TableCell component="th" scope="row">
                                        <Link href={"/movie/"+oneMovie.id}>{oneMovie.name}</Link>
                                    </TableCell>
                                    <TableCell align="right">{oneMovie.genres.map((genre) => (genre.name + " "))}</TableCell>
                                    <TableCell align="right">{oneMovie.year}</TableCell>
                                </TableRow>
                            ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
               </CardContent>
            </Card>
};

export default Movies