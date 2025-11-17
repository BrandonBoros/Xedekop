import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { PrimeReactProvider } from 'primereact/api'
import { Login } from './pages/Login'

import 'primereact/resources/themes/lara-light-blue/theme.css'; // Theme
import 'primereact/resources/primereact.min.css'; // Core CSS
import 'primeicons/primeicons.css'; // Icons
import 'primeflex/primeflex.css'; // Utility classes (optional)

createRoot(document.getElementById('root')).render(
  <StrictMode>
        <PrimeReactProvider>
            <Login></Login>
        </PrimeReactProvider>
  </StrictMode>,
)
