import { useState } from "react";
import { createContext } from "react"; 

export const AuthContext = createContext({
    isLogIn : false,
    loggIn : () => {},
    loggOut : () => {}
});

function AuthContextProvider ({children}) {
    const [isLogIn, setIsLogIn] = useState(false);

    function LoggIn() {
        setIsLogIn(true);
    }

    function LoggOut() {
        setIsLogIn(false);
    }

    const authContext = {
        isLogIn : isLogIn,
        loggIn: LoggIn,
        loggOut: LoggOut
    }

    return (
        <AuthContext.Provider value={authContext}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContextProvider;