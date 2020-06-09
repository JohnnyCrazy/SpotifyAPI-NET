import React from "react";
import CodeBlock from '@theme/CodeBlock'
import Tabs from '@theme/Tabs'
import TabItem from '@theme/TabItem'

const installCodeNuget =
  `Install-Package SpotifyAPI.Web -Version 6.0.0-beta.3
# Optional Auth module, which includes an embedded HTTP Server for OAuth2
Install-Package SpotifyAPI.Web.Auth -Version 6.0.0-beta.3
`;

const installReference =
  `<PackageReference Include="SpotifyAPI.Web" Version="6.0.0-beta.3" />
<!-- Optional Auth module, which includes an embedded HTTP Server for OAuth2 -->
<PackageReference Include="SpotifyAPI.Web.Auth" Version="6.0.0-beta.3" />
`;

const installCodeCLI =
  `dotnet add package SpotifyAPI.Web --version 6.0.0-beta.3
# Optional Auth module, which includes an embedded HTTP Server for OAuth2
dotnet add package SpotifyAPI.Web.Auth --version 6.0.0-beta.3
`;

const InstallInstructions = () => {
  return (<div style={{ padding: '30px' }}>
    <Tabs
      defaultValue="cli"
      values={[
        { label: '.NET CLI', value: 'cli' },
        { label: 'Package Manager', value: 'nuget' },
        { label: 'Package Reference', value: 'reference' }
      ]}>
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
  </div>);
}

export default InstallInstructions;
