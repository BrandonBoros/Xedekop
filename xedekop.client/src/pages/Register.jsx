import RegisterFields from "../components/RegisterFields";
import { useNavigate } from "react-router-dom";

export function Register() {
    const navigate = useNavigate();

    return (
        <div className="flex justify-content-center align-items-center min-h-screen">
            <div className="card flex flex-column gap-3 w-full" style={{ maxWidth: '400px' }}>
                <h1>Sign Up</h1>
                <RegisterFields navigate={navigate} />
            </div>
        </div>
    );
}