Dear Developer,

Thank you for your support.

This is a simple yet powerful tool that performs reverse searches, finding all assets in the project that reference a specified asset.  It's simple to use, supports searching multiple assets simultaneously, and is extraordinarily fast (usually instant).

-------------------------
INSTALLATION INSTRUCTIONS
-------------------------
This tool relies on 'ripgrep' for its speed, a freely downloadable command-line tool available on Mac, Windows, and Linux.  It is similar to the Linux/UNIX 'grep' command, but up to 10x faster. Please download and install it from the official site:
https://github.com/BurntSushi/ripgrep#installation

------------------
USAGE INSTRUCTIONS
------------------
This tool can be opened from the menu in:
	Tools->Find References To Asset
	or use the hotkey Ctrl/Cmd + E

On the first run, you'll need to specify the full path to ripgrep in the "Full path to 'rg'" field.  This is a one-time setup.

Usage notes:
- If you have an asset selected on opening the tool, it will auto-search for that asset on open.
- Multiple assets can be searched simultaneously.  You can do this either by selecting multiple assets when opening the tool, or adding them using the + button from the window.
- If "Exclude results not in build" is toggled on, then only results which are included in the build will be shown. Toggling this may slow performance slightly.
- After a search is performed, a new button "Find all references to results" will appear which can be used to search for references to the prior results. This allows continuously searching up through ancestors.

And that's it, I hope you love it!

If you have any questions, please drop us a line:
Discord: https://discord.gg/HdRaXt2M8N
Unity Forum: https://discussions.unity.com/t/released-find-references-to-asset/934790

We can't wait to see what you'll create next!

OmniShade
contact@omnishade.io
