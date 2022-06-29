import { MsalProvider } from '@azure/msal-react';
import * as msal from '@azure/msal-browser';
import React from 'react';
import App from 'app/App';

const msalConfig = {
    auth: {
        clientId: process.env.REACT_APP_CLIENT_ID,
        authority: process.env.REACT_APP_TENANT_ID
    },
    cache: {
        cacheLocation: 'localStorage' as 'localStorage'
    }
};

const msalInstance = new msal.PublicClientApplication(msalConfig);

const MsalComponent: React.FC = () => {
    return(<MsalProvider instance={msalInstance}>
        <App />
    </MsalProvider>);
};

export default MsalComponent;