import { adalFetch, AuthenticationContext, withAdalLogin } from 'react-adal';

export const adalConfig = {
    tenant: process.env.REACT_APP_TENANT_ID,
    clientId: process.env.REACT_APP_CLIENT_ID,
    endpoints: {
        api: ''
    },
    cacheLocation: 'localStorage' as 'localStorage'
};

export const authContext = new AuthenticationContext(adalConfig);

export const adalApiFetch = (fetch: (input: string, init: any) => Promise<any>, url: string, options: any) =>
    adalFetch(authContext, adalConfig.endpoints.api, fetch, url, options);

export const withAdalLoginApi = withAdalLogin(authContext, adalConfig.endpoints.api);
