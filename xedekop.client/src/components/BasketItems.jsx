import React, { useState, useEffect } from 'react';
import { DataView, DataViewLayoutOptions } from 'primereact/dataview';
import { Button } from 'primereact/button';
import { Skeleton } from 'primereact/skeleton';
import { classNames } from 'primereact/utils';
import "../styles/shop.css";
import { getOrderItems } from '../api/orderItemApi.js';
import { getPokemonById } from '../api/pokemonApi';

export default function BasketItems() {
    const [orderItems, setOrderItems] = useState([]);
    const [loading, setLoading] = useState(true);
    const [pokemons, setPokemons] = useState([])

    useEffect(() => {
        setLoading(true);

        getOrderItems().then(async (data) => {
            setOrderItems(data);

            const pokemonPromises = data.map((item) =>
                getPokemonById(item.pokemonId)
            );

            const pokemonResults = await Promise.all(pokemonPromises);

            const combined = data.map((order, i) => ({
                order,
                pokemon: pokemonResults[i]
            }));

            setPokemons(combined);
            setLoading(false);
        });
    }, []);



    const listItem = (order, pokemon, index) => (
        <div className="col-12" key={order.id}>
            <div className={classNames('pokemon-card flex flex-column xl:flex-row xl:align-items-start p-4 gap-4',
                { 'border-top-1 surface-border': index !== 0 })}>

                <img
                    className="w-9 sm:w-16rem xl:w-10rem sprite-hover border-round"
                    src={pokemon.sprite}
                    alt={pokemon.name}
                />

                <div className="flex flex-column sm:flex-row justify-content-between flex-1 gap-4">
                    <div className="flex flex-column gap-3">
                        <div className="text-2xl font-bold">{pokemon.name}</div>

                        <div className="flex gap-2">
                            <span className={`type-chip type-${pokemon.type1}`}>{pokemon.type1}</span>
                            {pokemon.type2 && (
                                <span className={`type-chip type-${pokemon.type2}`}>{pokemon.type2}</span>
                            )}
                        </div>
                    </div>

                    <div className="flex flex-column align-items-end gap-3">
                        <span className="text-2xl font-semibold">${order.unitPrice * order.quantity}</span>
                        <Button icon="pi pi-shopping-cart" className="p-button-rounded p-button-sm" />
                    </div>
                </div>
            </div>
        </div>
    );

    const itemTemplate = (item, index) => {
        if (loading) return <Skeleton className="w-full h-10rem border-round" />;
        if (!item) return null;

        return listItem(item.order, item.pokemon, index);
    };


    return (
        <div>
            <DataView
                value={pokemons}
                itemTemplate={itemTemplate}
            />
        </div>
    );
}
