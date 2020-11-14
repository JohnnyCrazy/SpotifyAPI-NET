module.exports = {
  docs: {
    'SpotifyAPI-NET': [
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
          'iplayableitem',
          'unit_testing',
        ],
      },
      {
        type: 'category',
        label: 'Authentication Guides',
        items: [
          'auth_introduction',
          'client_credentials',
          'implicit_grant',
          'authorization_code',
          'pkce',
          'token_swap',
        ],
      },
      'showcase',
      {
        type: 'category',
        label: 'Examples',
        items: [
          'example_asp',
          'example_blazor_wasm',
          'example_blazor',
          'example_cli_custom_html',
          'example_cli_persistent_config',
          'example_token_swap',
          'example_uwp',
        ],
      },
      {
        type: 'category',
        label: 'Migration Guides',
        items: ['5_to_6'],
      },
    ],
  },
};
