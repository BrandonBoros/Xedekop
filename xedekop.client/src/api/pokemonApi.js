import api from "./axios.js";

//GET ALL
export const getPokemons = async () => {
    const res = await api.get ("/pokemons");
    return res.data;
};