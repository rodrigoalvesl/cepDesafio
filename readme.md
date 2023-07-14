# cepDesafio 

This repository contains the cepDesafio application developed with Xamarin.Forms for Android. The application is designed to provide a convenient way to perform various tasks related to CEP (Brazilian ZIP code) lookup and management.

## Features

The cepDesafio application offers the following features:

1. **CEP Lookup**: The application allows users to search for CEPs (Brazilian ZIP codes) and retrieve information about the corresponding addresses, such as street name, neighborhood, city, and state.

2. **Search History**: Users can register and manage their search history within the application. All search queries are stored in a local database, allowing users to easily access their previous searches.

3. **Map View**: The application includes a map feature that displays pins on the map based on the addresses obtained from the CEP lookup. This provides users with a visual representation of the locations associated with the searched CEPs.

## Architecture

The cepDesafio application follows the Model-View-ViewModel (MVVM) architectural pattern. This pattern helps to separate the application's business logic from its presentation layer, promoting maintainability and testability. The MVVM pattern consists of the following components:

1. **Model**: The model represents the data and business logic of the application. It encapsulates the CEP lookup functionality, search history management, and map-related operations.

2. **View**: The view represents the user interface (UI) elements of the application. It consists of three tabbed pages, each serving a specific purpose: CEP lookup, search history, and map view.

3. **ViewModel**: The view model acts as a bridge between the model and the view. It exposes the necessary data and commands for the view to interact with the model. The view model also implements data binding, allowing automatic synchronization between the UI and underlying data.

## Getting Started

To run the cepDesafio application locally, follow these steps:

1. Clone this repository to your local machine.

2. Open the project in your preferred development environment that supports Xamarin.Forms.

3. Build the project to restore the NuGet packages and ensure all dependencies are resolved.

4. Configure the necessary API keys and connection strings required for the CEP lookup and map functionalities. These configurations may vary based on the specific implementation details.

5. Run the application on an Android emulator or a physical device.
