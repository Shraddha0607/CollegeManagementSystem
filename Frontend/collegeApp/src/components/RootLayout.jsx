import React from 'react'
import MainNavigation from './MainNavigation'
import { Outlet } from 'react-router-dom'

function RootLayout() {
    return (
        <>
            <MainNavigation />
            <main>
                <Outlet />
            </main>
        </>
    )
}

export default RootLayout
