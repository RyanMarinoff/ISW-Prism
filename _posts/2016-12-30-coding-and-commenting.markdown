---
layout: post
title: Coding and Commenting
date: 2016-12-30 17:00:00 -0500
categories: blog update code commenting
---

### `IDataLoader` Data Storage Fixes

I have moved the `IData` static class into the IDataLoader class and secured it as a private subclass. This will protect all data within the database from being mishandled outside of the `IDataLoader` static class. The accessors will be created as needed for whatever operation that will be performed within the application. Currently this includes the total number of items in each data-store. Each Load function now accesses the data-store directly. The test code now utilizes this count functionality during the loading of data to indicate success. If there is a data-store that is required for the Load functions to work but has not been filled, an exception will be thrown. This functionality will be changed in the future when needed.

### Data Integrity Check

During the checking of the Data integrity, I have found a few fields that were being used improperly, or were just not needed. These changes were made where appropriate. Vendors were utilized improperly within the models, and are not implemented as expected within Volusion. There will be a different method of work for this.

### Commenting and Comparison Operator Changes

`IDataLoader.ProcessCSV` private function has been refactored to `IDataLoader.ProcessData` to better reflect the intent of the function. The Data is no longer in CSV files, so we are just processing the data and returning the `List<Dictionary<string, string>>` back to the caller.

A new function is starting to be implemented called `UpdateData` in all models. This is intended to update all changes made to the model data. In the future, `IDataLoader` will need to track and process all changes made to each model and output the appropriate files for upload to Volusion. Only the Product update functionality has been implemented.

Comparison operators were adjusted. The intent for the current implementation is to have all comparison operations to refer back to the model's Equals(ID) call. This will allow for an ease to update the comparison operations into a single call. The Product model will handle the Equals(ID) call for all derived classes. This is not strictly enforced, but it is the programming style used.

A number of commenting headers were created for organization and readability.

### End of Day

Work will begin on creating the Views for this application. First will be the concept planning, then the implementation. After this, there will be the View Model creation to tie everything together. Testing will follow before new functionality will be implemented.
