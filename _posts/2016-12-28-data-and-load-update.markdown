---
layout: post
title: Data and Load Update
date: 2016-12-28 17:05:00 -0500
categories: blog update code data model
----
# IDataLoad and IData

I have started working on the Product loading and found that there are a few issues. It has been found that within the product descriptions, the pattern I was using to determine the different fields within the database existed. I found that instead of exporting the data from the company website in 'CSV - Comma Delimited Text File', export it in the 'PIPE - Pipe Delimited Text File' format. This will allow an easier processing of the data into the program's database. The only other time the pipe symbol is used is within the H1 tags.

An implementation of a small preliminary data store within the IDataLoad file is successful. It is a simple IData class that contains the lists of data. In the future this will all be internalized within the IDataLoad functionality, so that there will be no interface with the data other than read and write.

# ToString

The previous ToString methodology was displaying the description of all items. This is not what was intended. The name is what is needed. So this was changed, starting with the Category object. Categories have sub-categories, which will essentially be part of the Category name. The code now reflects this.

# ChildProduct Model

Due to how the data is stored and processed, there was a need to change the ChildProduct constructor. All product will be processed as a ParentProduct (main product model) until it is determined that the product is a Child of another product. This data is currently ordered by Parent then Children within the downloaded data. The program will assume that this is always a true statement. In the future this will be changed so that if the data is loaded in a different manner, the program will be able to handle it.

# Test Buttons

The Load Product test button has been modified to allow for testing of the data. Due to the requirement of having all other data loaded before the product data is loaded, the button functionality will check if the data is present. In the future, this will be incorporated into the IDataLoader functionality.

# Future

The wiki will need updated, as well as the ToString methods of all other models. To obtain a list of issues and future improvements, all blogs will be scanned for such information and implemented into the Issues part of the GitHub repository.
