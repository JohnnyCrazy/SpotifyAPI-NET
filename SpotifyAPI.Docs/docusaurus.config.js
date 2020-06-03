const versions = require('./versions.json');

module.exports = {
  title: 'SpotifyAPI-NET',
  tagline: '🔊 A Client for the Spotify Web API, written in C#/.NET',
  url: 'https://johnnycrazy.github.io/SpotifyAPI-NET',
  baseUrl: '/',
  favicon: 'img/favicon.ico',
  organizationName: 'JohnnyCrazy', // Usually your GitHub org/user name.
  projectName: 'SpotifyAPI-NET', // Usually your repo name.
  themeConfig: {
    sidebarCollapsible: true,
    prism: {
      additionalLanguages: ['csharp'],
    },
    navbar: {
      title: 'SpotifyAPI-NET',
      logo: {
        alt: 'SpotifyAPI-NET',
        src: 'img/logo.svg',
      },
      links: [
        {
          activeBasePath: 'docs',
          label: 'Docs',
          position: 'left',
          items: [
            {
              label: 'Latest/Next',
              to: 'docs/next/introduction',
            },
            {
              label: versions[0],
              to: 'docs/home',
            },
            ...versions.slice(1).map((version) => ({
              label: version,
              to: `docs/${version}/home`,
            }))
          ]
        },
        { to: 'news', label: 'News', position: 'left' },
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
          sidebarPath: require.resolve('./sidebars.js'),
          // Please change this to your repo.
          editUrl:
            'https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/',
          showLastUpdateAuthor: true,
          showLastUpdateTime: true,
        },
        blog: {
          path: 'news',
          routeBasePath: 'news',
          showReadingTime: true,
          feedOptions: {
            type: 'all',
            copyright: `Copyright © ${new Date().getFullYear()} Jonas Dellinger.`,
          },
          // Please change this to your repo.
          editUrl:
            'https://github.com/JohnnyCrazy/SpotifyAPI-NET/edit/master/SpotifyAPI.Docs/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
