# [Log Janitor][github-repo]

[![Build Status][build-badge]][build-status] [![Discord][discord-badge]][discord-invite] [![GitHub Sponsors][sponsor-badge]][sponsor-link]

**Log Janitor** is a plugin for managing [RebornBuddy][rebornbuddy] logs. It automatically deletes log files older than a certain date and adds a "View Logs" button for quick log folder access.

[github-repo]: https://github.com/bismuth-dev/LogJanitor "LogJanitor on GitHub"
[build-badge]: https://img.shields.io/github/workflow/status/bismuth-dev/LogJanitor/Publish?style=plastic&logo=github&label=Publish&color=success
[build-status]: https://github.com/bismuth-dev/LogJanitor/actions "Build Server"
[discord-badge]: https://img.shields.io/discord/543591035847311360.svg?label=&logo=discord&logoColor=ffffff&color=7389D8&labelColor=7389D8
[discord-invite]: https://discord.gg/4Y5HSjP "bismuth.dev Discord"
[sponsor-badge]: https://shields.io/badge/-Sponsors-555?logo=githubsponsors&style=flat
[sponsor-link]: https://github.com/sponsors/TheManta

## Installation

### Prerequisites

- [RebornBuddy][rebornbuddy] with active license (paid)
- [repoBuddy][repobuddy] for automatic installation and updates (free)

[rebornbuddy]: https://rebornbuddy.com
[repobuddy]: https://rebornbuddy.wiki/users/#installing-repobuddy-and-other-add-ons

### Adding Log Janitor to repoBuddy

If your repoBuddy config is missing Log Janitor, you can add it via repoBuddy's settings menu on the Repositories tab:

- **Name:** `LogJanitor`
- **Type:** `Plugin`
- **URL:** `https://github.com/bismuth-dev/LogJanitor.git/trunk`

## Usage

To quickly open the `RebornBuddy/Logs/` folder, click the "View Logs" button on the right side of the main window. The current log file will be pre-selected for easy uploading. This button is available even when the plugin is disabled.

![View Logs button](https://i.imgur.com/qrF1cOr.png)

To automatically delete older logs, enable "Log Janitor" in the Plugins tab. Max file age can be controlled in the plugin settings menu. The default max age is 30 days, and no files are deleted until Log Janitor is enabled.

TODO: Add screenshot of settings
