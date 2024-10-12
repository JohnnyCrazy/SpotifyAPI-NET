const versions = require('./versions.json');

module.exports = {
  title: 'SpotifyAPI-NET',
  tagline: '🔊 A Client for the Spotify Web API, written in C#/.NET',
  url: 'https://johnnycrazy.github.io',
  baseUrl: '/SpotifyAPI-NET/',
  favicon: 'img/favicon.ico',
  organizationName: 'JohnnyCrazy', // Usually your GitHub org/user name.
  projectName: 'SpotifyAPI-NET', // Usually your repo name.
  customFields: {
    LATEST_VERSION: process.env.LATEST_VERSION ?? '?.?.?',
  },
  themeConfig: {
    prism: {
      additionalLanguages: ['csharp'],
    },
    navbar: {
      title: 'SpotifyAPI-NET',
      logo: {
        alt: 'SpotifyAPI-NET',
        src: 'img/logo.svg',
      },
      items: [
        {
          activeBasePath: 'docs',
          label: 'Docs',
          position: 'left',
          items: [
            {
              label: '7.X (current)',
              to: 'docs/introduction',
            },
            ...versions.map((version) => ({
              label: version,
              to: `docs/${version}/home`,
            })),
          ],
        },
        {
          href: 'https://github.com/JohnnyCrazy/SpotifyAPI-NET',
          label: 'GitHub',
          position: 'right',
        },
      ],
    },
    footer: {
      style: 'dark',
      copyright: `Copyright © ${new Date().getFullYear()} Jonas Dellinger. Built with Docusaurus.`,
    },
  },
  presets: [
    [
      '@docusaurus/preset-classic',
      {
        docs: {
          sidebarCollapsible: true,
          sidebarPath: require.resolve('./sidebars.js'),
          // Please change this to your repo.
          editUrl: 'https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/',
          showLastUpdateAuthor: true,
          showLastUpdateTime: true,
          lastVersion: 'current',
          versions: {
            current: {
              label: '7.X',
              path: '',
            },
          },
        },
        blog: {
          path: 'news',
          routeBasePath: 'news',
          showReadingTime: true,
          feedOptions: undefined,
          // Please change this to your repo.
          editUrl: 'https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
