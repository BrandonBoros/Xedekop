import React, { useState, useEffect } from 'react';
import { InputText } from 'primereact/inputtext';
import { Password } from 'primereact/password';
import { Button } from 'primereact/button';

export default function LoginFields() {
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const [isDisabled, setDisable] = useState(true);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if (email && username && password) {
            setDisable(false);
        } else {
            setDisable(true);
        }
    }, [email, username, password]);

    const load = () => {
        setLoading(true);
        setTimeout(() => {
            setLoading(false);
        }, 2000);
    };

    return (
        <>
            <div className="p-inputgroup flex-1">
                <span className="p-inputgroup-addon">@</span>
                <InputText placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)}/>
            </div>

            <div className="p-inputgroup flex-1">
                <span className="p-inputgroup-addon">
                    <i className="pi pi-user"></i>
                </span>
                <InputText placeholder="Username" value={username} onChange={(e) => setUsername(e.target.value)}/>
            </div>

            <div className="p-inputgroup flex-1">
                <span className="p-inputgroup-addon">#</span>
                <Password placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)}/>
            </div>

            <Button label="Submit" icon="pi pi-check" raised loading={loading} onClick={load} disabled={isDisabled}/>
        </>
    )
}