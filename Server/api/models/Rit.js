/**
 * Rit.js
 *
 * @description :: TODO: You might write a short summary of how this model works and what it represents here.
 * @docs        :: http://sailsjs.org/documentation/concepts/models-and-orm/models
 */

module.exports = {

  autoCreatedAt: false,

  attributes: {

    car: {
      model: 'Car'
    },

  	description:{
  		type: 'string'
  	},

  	listCoordinates: {
  		collection: 'Coordinate'
  	}
  }
};
