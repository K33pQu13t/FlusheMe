# FlushMe

Do you want to take care of your data if you are away from your computer for a long time and somebody would try to get access? That's the solution!

A configurable program which would run each time OS ran, check if it is time to flush and make executions according to configurations.

## Features

- Clear browsers data such as history, bookmarks, passwords, etc...
- Clear directories and files
- Run external programms, with possibility to pass arguments, open folders, web-links, so it's free to expand any scenarios you would like
- Clear configuration sections after executing so it's unable to anybody to look which exactly configuration was executed

Just add this program to startup (do not forget to set **run arguments** described in [syntax](#syntax) section), and setup [configuration](#configurations) by your needs.

For now it's performing actions in this order:

Clear browsers data **->** execute apps **->** clear files and directories **->** clear config file.

May be it would be possible to configure it's order in the future.

<br><br>

# Syntax

If run with no arguments - just shows a link to documentation in order you don't know how to use it.

To perform actions described in configurations, run it with argument `--perform` or `-p`. That doesn't mean what all configures would be performed, they would according to [daysAwayToProcess](#daysawaytoprocess) option check. 

You can add argument `--force` or `-f` to skip days check and perform whole configurations anyway.

If you want to hide application window (you probably do), just pass argument `--silent` or `-s`. By default window is shown in order to inform you about syntax if you didn't know it or forget it.

If some step could not be performed (like, one of paths you specified to delete does not exist), then it just skips it, so whole execution would be processed as much as possible with **no errors** be throwen.

Be noticed what when you add this program to startup, you **need to pass** `--perform` argument in order to use it the way it was designed.

<br><br>

# Configurations

Config is stored in config.json file. If you deleted it, it would be created on start with default options.

Let's look around options.

<br>

## Common options

This is common options. It contains 2 global options to refer if relative option in concrete config is `null`. It also stores a date of last program run, and rewrites it each time program runs.

<br>

#### **daysAwayToProcess**

*Possible values: `null` or any natural number*

That option specified how much days must pass from last run to execute any further options. If it is not time yet, then config section would not be executed. `null` for never (**if `null` is setted in global config - no further configs would be executed!**). `0` for every time. If some furhter configs would have that options set by `null`, script would refer to that option to decide is it time to execute. So, it's default options for whole configs, but you can specify more concrete value for same option in configs you need. So, for example, if global option set by `0`, but in concrete section same option set by `5`, that section would be executed only if 5 days passed.

It counts calendar days without time, so, if it is, for example, setted to `5`, last run was some time at *1st of january*, then it would be executed on *6st of january* since 00:00.

<br>

#### **autoClearOnProcessed**

*Possible values: `null`, `false` or `true`*

That option specifies should that config section be cleared after execution. Setting this global option to `true` would mean to clear **WHOLE** configs after **ANY** of configs executed. In concrete config section that option setted to `true` would mean clear only that concrete section. `false` or `null` value make no effects.

<br>

#### **lastRunDate**

*Possible values: `dateTime` formatted to dd.MM.yyyy HH:mm:ss*

As it says, last date time when this program ran (even if no configs were executed). **Do not** set this option manualy. It uses to decide is it time to execute section by calculation how much days pass from last run to now and comparing it to [daysAwayToProcess](#daysawaytoprocess) option.

<br><br>

## browserCleaningConfig

That section configures browsers cleaning. It cleans browsers data such as history, bookmarks, passwords, etc...

<br>

#### **daysAwayToProcess**

[As described in global](#daysawaytoprocess)

<br>

#### **autoClearOnProcessed**

[As described in global](#autoclearonprocessed)

<br>

#### **cleanFirefox**

*Possible values: `null`, `false` or `true`*

If setted to `true`, then cleans Firefox data. Otherwise not.

<br>


#### **cleanGoogleChrome**

*Possible values: `null`, `false` or `true`*

If setted to `true`, then cleans Google Chrome data. Otherwise not.

<br><br>

## appExecutionConfig

Configures which progmrams must be run. It also allows to pass some arguments. That's not necessary to be a program, it also can be a directory, or even web-url.

<br>

#### **daysAwayToProcess**

[As described in global](#daysawaytoprocess)

<br>

#### **autoClearOnProcessed**

[As described in global](#autoclearonprocessed)

<br>

#### **runConfigs**

*Possible values: `null` or `array of objects`*

Sets a configs for run applications. Fields:

##### **Path**

*Possible values: `null` or `string`*

Sets path to application to run, directory to open (network directory), url to open in browser

##### **Arguments**

*Possible values: `null` or `array of strings`*

Sets arguments to pass to running application

<br><br>

## fileCleaningConfig

Configures cleaning files and directories.

<br>

#### **daysAwayToProcess**

[As described in global](#daysawaytoprocess)

<br>

#### **autoClearOnProcessed**

[As described in global](#autoclearonprocessed)

<br>

#### **filePathsToDelete**

*Possible values: `null` or `array of objects`*

Configures paths to clean. Fields:

##### **Path** 

*Possible values: `null` or `string`*

Sets paths to clean

##### **IncludeThisPathToDelete**

*Possible values: `null`, `false` or `true`*

If [Path](#path-1) is directory path, `true` means delete this directory too. Otherwise deletes only files and directories inside that directory. No effect for file path.

<br><br>

# Using

Feel free to use it and modify it all the way you want, I don't care. You can contribute if you want, let's see what comes out. 

If you feel like you want to donate, there is my pockets:

- [Qiwi](https://qiwi.com/n/K33PQU13T)