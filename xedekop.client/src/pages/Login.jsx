import LoginFields from "../components/LoginFields";
import { useNavigate } from "react-router-dom";


export function Login() {
    const navigate = useNavigate();


    return (
        <div className="flex justify-content-center align-items-center min-h-screen">
            <div className="card flex flex-column gap-3 w-full" style={{ maxWidth: '400px' }}>
                <h1>Login</h1>
                <LoginFields navigate={navigate} />
            </div>
        </div>
    );
}