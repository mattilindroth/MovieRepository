import React, {useState } from 'react';
import {useParams } from "react-router-dom";
import Movie from '../Models/Movie';

import {Table, TableContainer, Paper, TableRow, TableCell, TableBody, Rating, Card, CardContent, Typography, TextField } from '@mui/material';

const AddMovie:React.FC = ():JSX.Element => {

    const [movie, setMovie] = useState<Movie>(
        {
            id:"", 
            name: "",	
            synopsis: "", 
            actors: [], 
            director: {firstName: "", lastName: ""}, 
            ageLimit: 0,	
            year: 0, 
            genres: [], 
            rating: 0
        });  

    return <Card sx={{ minWidth: 275 }}>
            <CardContent>
                <Typography variant="h3">Add new movie</Typography>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 650, maxWidth: 1400 }} aria-label="simple table">
                        <TableBody>
                            {/* Name */}
                            <TableRow>
                                <TableCell><TextField required id="name" label="Name" variant ="standard" fullWidth /></TableCell>
                            </TableRow>

                            {/* Rating */}
                            <TableRow>
                                <TableCell><Rating name="simple-controlled" value={3} onChange={(event, newValue) => {movie.rating = newValue? newValue : 0;}} /></TableCell>
                            </TableRow>

                            {/* Genres */}
                            <TableRow >
                                <TableCell><TextField id="genres" label="Genres" variant ="standard" /></TableCell>
                            </TableRow>

                            {/* Synopsis */}
                            <TableRow >
                                <TableCell><TextField id="synopsis" label="Synopsis" variant ="standard" /></TableCell>
                            </TableRow>

                            {/* Year */}
                            <TableRow >
                                <TableCell><TextField id="year" label="Genres" variant ="standard" /></TableCell>
                            </TableRow>

                            {/* Actors */}
                            <TableRow >
                                <TableCell><TextField id="actors" label="Actors" variant ="standard" /></TableCell>
                            </TableRow>

                            {/* Director */}
                            <TableRow >
                                <TableCell><TextField id="director" label="Director" variant ="standard" /></TableCell>
                            </TableRow>

                            {/* Age limit */}
                            <TableRow >
                                <TableCell><TextField id="ageLimit" label="Age limit" variant ="standard" /></TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
        </CardContent>
        </Card>

       
};

export default AddMovie