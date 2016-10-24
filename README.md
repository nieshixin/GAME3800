# GAME3800

## Setup Instructions

#### UnityYAMLMerge

To deal with scene edit conflicts, we'll be trying to use a tool that's shipped with Unity called [UnityYAMLMerge](https://docs.unity3d.com/Manual/SmartMerge.html).
Please follow these instructions so that you can deal with scene conflicts correctly:

##### IF YOU USE SOURCETREE

	Go to Tools > Options > Diff.
	Select Custom in the Merge Tool dropdown.
	Type the path to your UnityYAMLMerge in the Merge Command text field.
  On Windows, this is typically something like "C:\Program Files\Unity\Data\Tools\UnityYAMLMerge.exe"
	Type "merge -p $BASE $REMOTE $LOCAL $MERGED" (no quotes) in the Arguments text field.

##### IF YOU USE GIT (WITHOUT SOURCETREE)

	[merge]
	tool = unityyamlmerge

	[mergetool "unityyamlmerge"]
	trustExitCode = false
	cmd = '<path to UnityYAMLMerge>' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"


NOTE: Adding this to your gitconfig won't play nicely with SourceTree. If you do use SourceTree, use the instructions for it above.

## Pushing Changes
