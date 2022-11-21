import Person from './Person';

type Movie = {
	id: String,
	name: String,
	synopsis: String,
	actors: Array<Person>,
	director: Person,
	ageLimit: number,
	year: number
	genres: Array<String>,
	rating: number
}

export default Movie;