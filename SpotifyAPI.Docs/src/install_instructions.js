import CodeBlock from '@theme/CodeBlock';
import TabItem from '@theme/TabItem';
import Tabs from '@theme/Tabs';
import React from 'react';

// Will be removed after beta releases
const VERSION = '6.0.0';

const installCodeNuget = `Install-Package SpotifyAPI.Web
# Optional Auth module, which includes an embedded HTTP Server for OAuth2
Install-Package SpotifyAPI.Web.Auth
`;

const installReference = `<PackageReference Include="SpotifyAPI.Web" Version="${VERSION}" />
<!-- Optional Auth module, which includes an embedded HTTP Server for OAuth2 -->
<PackageReference Include="SpotifyAPI.Web.Auth" Version="${VERSION}" />
`;

const installCodeCLI = `dotnet add package SpotifyAPI.Web
# Optional Auth module, which includes an embedded HTTP Server for OAuth2
dotnet add package SpotifyAPI.Web.Auth
`;

const InstallInstructions = () => {
  return (
    <div style={{ padding: '10px' }}>
      <Tabs
        defaultValue="cli"
        values={[
          { label: '.NET CLI', value: 'cli' },
          { label: 'Package Manager', value: 'nuget' },
          { label: 'Package Reference', value: 'reference' },
        ]}
      >
        <TabItem value="cli">
          <CodeBlock metastring="shell" className="shell">
            {installCodeCLI}
          </CodeBlock>
        </TabItem>
        <TabItem value="nuget">
          <CodeBlock metastring="shell" className="shell">
            {installCodeNuget}
          </CodeBlock>
        </TabItem>
        <TabItem value="reference">
          <CodeBlock metastring="xml" className="xml">
            {installReference}
          </CodeBlock>
        </TabItem>
      </Tabs>
    </div>
  );
};

export default InstallInstructions;
