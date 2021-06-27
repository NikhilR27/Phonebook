import axios from 'axios';

export default {
    async getPhoneBook()
    {
        const response = await axios.get('/');
        return response.data;
    },
    async getPhoneBookEntries()
    {
        const response = await axios.get('/');
        return response.data;
    },
    async addEntryToPhoneBook(payload)
    {
        return await axios.post('', payload);
    }

}