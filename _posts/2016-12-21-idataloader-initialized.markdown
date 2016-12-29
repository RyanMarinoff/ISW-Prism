---
layout: post
title: IDataLoader Initialized
date: 2016-12-21 15:51:00 -0500
categories: blog update code mvvm ioc idataloader
---
# Set all accessors for all data fields within class models

The initial setup of the model classes has all class fields set to private.
This makes everything hidden during the use of the class. Also, this will
make all data to be accessible only on certain terms. The intent is to ensure
that all data that is placed within the class will be safe and accurate. Due
to not implementing this functionality till a later date, I have created
an accessor for each data type. The ID field is unique, where after creation this
field is not able to be changed. Changing this field will indicate a different
physical item.

# Setup testing environment for IDataLoader

As I develop the IDataLoader, I needed to have a way to test. I created an
interface within the MainWindow that consists of 4 buttons, one for each
main model. Each test button will ask for the .csv formatted data file. This
information is then passed to the IDataLoader load functions which would then
load all the data. The data is currently stored in a List of the type of
object used.

# Set data loading functionality within IDataLoader

Using pre-existing code examples as stated yesterday, I have completed the preliminary
loading of data for the Vendor, Option and Category models. Currently the purpose
is to get the data loaded into the application. Actual use and manipulation of the
data is not part of the intent.

# Tested IDataLoader

The tests for the three completed models are successful. To test that the data has
been entered, a simple count of the number of objects placed within each list is
displayed. Data integrity was not assessed at this time. This should be done after
the Wiki is completed, before finishing with the Products.

# End of Day

The end of the day came faster than expected. Due to the requirements of store
duties being a higher priority, I was pulled away multiple times from this project.
Wiki updates will be performed tomorrow morning.
