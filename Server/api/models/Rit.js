/**
 * Rit.js
 *
 * @description :: TODO: You might write a short summary of how this model works and what it represents here.
 * @docs        :: http://sailsjs.org/documentation/concepts/models-and-orm/models
 */

module.exports = {

  autoUpdatedAt: false,
  createdAt: false,

  attributes: {

    id: {
      type: 'integer',
      primaryKey: true,
    },

    car:{
      model: 'car'
    },

  	description:{
  		type: 'string'
  	},

    // Add reference to
    coordinates: {
  		collection: 'coordinate',
      via: 'rit'
  	}

  }
};

