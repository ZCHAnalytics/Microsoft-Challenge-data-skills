

## backup 
![image](https://github.com/ZCHAnalytics/Microsoft-Challenge-data-skills/assets/146954022/3a45e126-e7f3-47e3-84f2-144661ee9baa)


## Configure continuous backup and recovery

Settings that aren't restored to the new account:

Firewall, VNET, private endpoint settings.
Consistency settings. By default, the account is restored with session consistency.
Regions.
Stored procedures, triggers, UDFs.

## Point-in-time recovery
Restore Scenarios
Restore deleted account
The information needed for the restore is the timestamp right before the delete, the account name of the deleted account, and the target name to be restored as. 

Restore data of an account in a particular region
The information needed for the restore is the desired timestamp, and the target name to be restored as.

Recover from an accidental write or delete operation within a container with a known restore timestamp.
If you know the timestamp when the accidental operation was done, you can do a point in time restore into another account at the desired timestamp to recover to.

Restore an account to a previous point in time before the accidental delete of the database. 
use the event feed pane to determine when the database was deleted, and find the restore time. 

Restore an account to a previous point in time before the accidental delete or modification of the container properties
use the event feed pane to determine when the container was created, modified, or deleted and find the restore time. 
