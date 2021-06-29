FROM node:lts-alpine

WORKDIR /app/PhoneBook.UI/phonebookui
# install simple http server for serving static content
RUN npm install -g http-server

# # make the 'app' folder the current working directory
# WORKDIR /app/PhoneBook.UI/phonebookui

# copy both 'package.json' and 'package-lock.json' (if available)
COPY package*.json ./

# install project dependencies
RUN npm install

# copy project files and folders to the current working directory (i.e. 'app' folder)
COPY /PhoneBook.UI .

# build app for production with minification
WORKDIR /app/PhoneBook.UI/phonebookui/phonebookui
RUN npm install
RUN npm run build

EXPOSE 9800
CMD [ "http-server", "-p 9800", "dist" ]