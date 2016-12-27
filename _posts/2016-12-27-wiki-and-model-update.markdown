---
layout: post
title: Wiki and Model Update
date: 2016-12-27 16:55:00 -0500
categories: blog update code wiki model
---
# Wiki

I have finished updating the Wiki for the current version of the application. During this process, I have made a few changes to the name of the fields to better represent the different data points. I have also readied the Product classes for use.

# Code Edit

I have also updated the application to import the product data into the database. This is done within the IDataLoader as LoadProducts. LoadProducts has not been completed due to the next section needing to be completed.

# Overloads

Added overloaded ToString(), Equals, and equal comparison operators in all classes except for the products. This will allow for easier use of the objects during development by allowing the proper comparisons between products. Equitability is based off the id of the objects. The data within is not yet taken into effect. This issue ‘bug’ will be worked on in the future.

# End of Day

Overloads still need work, with the content data issue that exists. May remove a bit of code for this aspect to work properly. Wiki need updated to include overloads. LoadProducts needs completed. Issue tracker needs updated to include all issues discovered within code.
