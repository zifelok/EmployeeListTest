import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Create } from './components/Create'

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/create' component={ Create } />
</Layout>;
