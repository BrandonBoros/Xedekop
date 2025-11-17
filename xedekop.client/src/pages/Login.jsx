import LoginFields from "../components/LoginFields";

export function Login() {
    return (
        <>
            <div className="flex justify-content-center align-items-center min-h-screen">
                <div className="card flex flex-column gap-3 w-full" style={{ maxWidth: '400px' }}>
                    <h1>Login</h1>

                    <LoginFields />
                </div>
            </div>
        </>
    );
}