module.exports = {
  title: 'SpotifyAPI-NET',
  base: '/SpotifyAPI-NET/',
  description: '🔉 An API for the Spotify-Client and the Spotify Web API, written in C#/.NET',
  themeConfig: {
    repo: 'JohnnyCrazy/SpotifyAPI-NET',
    repoLabel: '🚀 GitHub',
    docsDir: 'SpotifyAPI.Docs/docs',
    editLinks: true,
    editLinkText: 'Help us improve this page!',
    sidebar: 'auto',
    sidebarDepth: 0,
    lastUpdated: 'Last Updated',
    serviceWorker: {
      updatePopup: true
    },
    nav: [
      { text: 'Home', link: '/' },
      {
        text: 'SpotifyAPI.Web',
        items: [
          { text: 'Getting Started', link: '/web/getting_started' },
          { text: 'Examples', link: '/web/examples' },
          { text: 'Proxy', link: '/web/proxy' },
          { text: '- Albums', link: '/web/albums' },
          { text: '- Artists', link: '/web/artists' },
          { text: '- Browse', link: '/web/browse' },
          { text: '- Follow', link: '/web/follow' },
          { text: '- Library', link: '/web/library' },
          { text: '- Personalization', link: '/web/personalization' },
          { text: '- Player', link: '/web/player' },
          { text: '- Playlists', link: '/web/playlists' },
          { text: '- Profiles', link: '/web/profiles' },
          { text: '- Search', link: '/web/search' },
          { text: '- Tracks', link: '/web/tracks' },
          { text: 'Utilities', link: '/web/utils' },
        ]
      },
      {
        text: 'SpotifyAPI.Auth',
        items: [
          { text: 'Getting Started', link: '/auth/getting_started' },
          { text: '- ImplicitGrantAuth', link: '/auth/implicit_grant' },
          { text: '- TokenSwapAuth', link: '/auth/token_swap' },
          { text: '- AutorizationCodeAuth', link: '/auth/authorization_code' },
          { text: '- ClientCredentialsAuth', link: '/auth/client_credentials' },
        ]
    },
    ]
  }
}
