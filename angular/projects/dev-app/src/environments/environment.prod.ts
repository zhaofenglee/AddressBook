import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'AddressBook',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44330/',
    redirectUri: baseUrl,
    clientId: 'AddressBook_App',
    responseType: 'code',
    scope: 'offline_access AddressBook',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44330',
      rootNamespace: 'JS.Abp.AddressBook',
    },
    AddressBook: {
      url: 'https://localhost:44345',
      rootNamespace: 'JS.Abp.AddressBook',
    },
  },
} as Environment;
