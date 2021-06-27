import axios from 'axios';

export default {
    async getPhoneBook()
    {
        const response = await axios.get('/PhoneBook/entry');
        return response.data;
    },
    async getPhoneBookEntries()
    {
        const response = await axios.get('/phonebook/entry');
        return response.data;
    },
    async addEntryToPhoneBook(payload)
    {
        return await axios.post('', payload);
    }

}