import React, {useState} from "react";

export function LoginModal({setIsAuthenticated}: { setIsAuthenticated: React.Dispatch<React.SetStateAction<boolean>> }) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        try {
            const response = await fetch('http://localhost:5126/api/Auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({username, password}),
            });

            if (response.ok) {
                setIsAuthenticated(true);
                console.log('Login successful');
            } else {
                alert('Login failed');
            }
        } catch (error) {
            console.error('Error logging in:', error);
        }
    };

    return (
        <div className="min-h-screen bg-gray-100 flex items-center justify-center">
            <div className="bg-white p-8 rounded shadow-md">
                <h2 className="text-2xl mb-4">Login</h2>
                <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    className="mb-4 p-2 border rounded w-full"
                />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    className="mb-4 p-2 border rounded w-full"
                />
                <button onClick={handleLogin} className="bg-blue-500 text-white p-2 rounded w-full">
                    Login
                </button>
            </div>
        </div>
    );
}