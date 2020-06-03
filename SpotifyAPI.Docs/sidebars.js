module.exports = {
  docs: {
    'SpotifyAPI.NET': [
      'introduction',
      'getting_started',
      {
        type: 'category',
        label: 'Guides',
        items: [
          'error_handling',
          'configuration',
          'logging',
          'proxy',
          'pagination',
          'retry_handling',
          'unit_testing'
        ]
      },
      {
        type: 'category',
        label: 'Authentication Guides',
        items: [
          'auth_introduction',
          'client_credentials',
          'implicit_grant',
          'authorization_code'
        ]
      },
      {
        type: 'category',
        label: 'Examples',
        items: []
      },
    ]
  }
};
