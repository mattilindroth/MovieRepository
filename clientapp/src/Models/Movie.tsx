import Person from './Person';
import Genre from './Genre';

type Movie = {
	id: String,
	name: String,
	synopsis: String,
	actors: Array<Person>,
	director: Person,
	ageLimit: number,
	year: number
	genres: Array<Genre>,
	rating: number
}

export default Movie;