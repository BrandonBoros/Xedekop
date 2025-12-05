import api from "./axios.js";


//GET ALL
export const getOrderItems = async () => {
    const res = await api.get("/OrderItem");
    return res.data;
};

// CREATE
export const createOrderItem = async (pokemonId, unitPrice) => {
    const res = await api.post(`/OrderItem/${pokemonId}/${unitPrice}`);
    return res.data;
};

// UPDATE
export const updateOrderItem = async (id, pokemonId, unitPrice, quantity) => {
    const res = await api.put(`/OrderItem/${id}/${pokemonId}/${unitPrice}/${quantity}`);
    return res.data;
};

// DELETE
export const deleteOrderItem = async (id) => {
    const res = await api.delete(`/OrderItem/${id}`);
    return res.data;
};