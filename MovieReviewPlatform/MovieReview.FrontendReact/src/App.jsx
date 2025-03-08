import React, { useEffect, useState } from "react"
import { getPopularMovies } from "./services/tmdbService"

const MoviesList = ({ movies = [] }) => {
  if (!Array.isArray(movies)) {
    console.error("Movies is not an array:", movies)
    return <p>No movies available.</p>
  }

  return (
    <div>
      {movies.length > 0 ? (
        movies.map((movie) => <div key={movie.id}>{movie.title}</div>)
      ) : (
        <p>No movies found.</p>
      )}
    </div>
  )
}

const App = () => {
  const [movies, setMovies] = useState([]) // Define state in App

  useEffect(() => {
    const fetchMovies = async () => {
      try {
        const response = await getPopularMovies();
        console.log("Fetched movies:", response);
  
        // Check if response contains $values
        const moviesArray = response.results?.$values || response.results || [];
  
        setMovies(moviesArray);
      } catch (error) {
        console.error("Error fetching movies:", error);
      }
    };
  
    fetchMovies();
  }, []);

  return (
    <div>
      <h1>Movie Explorer 🎥</h1>
      <MoviesList movies={movies} /> {/* Pass movies as props */}
    </div>
  )
}

export default App