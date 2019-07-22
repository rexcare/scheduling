import React from 'react';
import { ApiClient, GroupDto } from '../../generated/backend';

const Home: React.FC = () => {
  getGroups();
  return <h2>Home</h2>;
};

function getGroups() {
  const apiClient: ApiClient = new ApiClient("https://localhost:5001");
  apiClient.groups_GetAllGroups()
  .then(groups => {
    groups.forEach(g => {
      console.log(`Group ${g.id}: ${g.name}`);
    })
  });
}

export default Home;
