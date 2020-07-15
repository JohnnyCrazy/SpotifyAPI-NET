import React from "react";
import CodeBlock from '@theme/CodeBlock'
import Tabs from '@theme/Tabs'
import TabItem from '@theme/TabItem'

// Will be removed after beta releases
const VERSION = '6.0.0-beta.9';

const installCodeNuget =
  `Install-Package SpotifyAPI.Web -Version ${VERSION}
# Optional Auth module, which includes an embedded HTTP Server for OAuth2
Install-Package SpotifyAPI.Web.Auth -Version ${VERSION}
`;

const installReference =
  `<PackageReference Include="SpotifyAPI.Web" Version="${VERSION}" />
<!-- Optional Auth module, which includes an embedded HTTP Server for OAuth2 -->
<PackageReference Include="SpotifyAPI.Web.Auth" Version="${VERSION}" />
`;

const installCodeCLI =
  `dotnet add package SpotifyAPI.Web --version ${VERSION}
# Optional Auth module, which includes an embedded HTTP Server for OAuth2
dotnet add package SpotifyAPI.Web.Auth --version ${VERSION}
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
