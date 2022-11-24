import React, { useState } from 'react';
import {Button, Card, TextField, TableContainer, Table, Paper, TableBody, TableCell, Link, TableRow } from '@mui/material';
import Movie from '../Models/Movie';
import axios from 'axios';

const Search:React.FC = ():JSX.Element => {

	const [searchTerm, setSearchTerm] = useState<String>("");

	const [searchResult, setResult] = useState<Array<Movie>>([]);

	const backendUrl = process.env.BACKEND_URL;

	function handleSearchTermChange(event: any) {
		setSearchTerm(event.target.value);
	}

	function handleSubmit(event: any) {
		if(searchTerm.length >2) {
			axios.get(backendUrl + "/movies/search/" + searchTerm).then(function(result) {
				let foundMovies:Array<Movie> = result.data;
				setResult(foundMovies);
			});
		} else {
			//Todo perhaps hint the user about too short search term
		}
	}

    return <div> <Card sx={{ minWidth: 275 }}>
					<TextField required id="searchTerm" label="Search" variant ="standard" onChange={handleSearchTermChange} />
					<Button onClick={handleSubmit} >Search</Button>
				</Card>
				<Card sx={{ minWidth: 275 }}>
					<TableContainer component={Paper}>
						<Table sx={{ minWidth: 650, maxWidth: 1400 }} aria-label="simple table">
							<TableBody>
								{searchResult.map((movie: Movie) => (
									<TableRow>
										<TableCell component="th" scope="row">
											<Link href={"/movie/"+movie.id}>{movie.name}</Link>
										</TableCell>
									</TableRow>
								))}
							</TableBody>
						</Table>
					</TableContainer>
				</Card>
			</div>
};

export default Search